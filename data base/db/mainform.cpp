#include "mainform.h"
#include "ui_mainform.h"

MainForm::MainForm(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainForm)
{
    ui->setupUi(this);
    setWindowTitle("Складской модуль");
    this->setStyleSheet(QString("color:#F5F5F5; background:#191970;"));
    ui->tableView->setStyleSheet(QString("color:Black; background:#F5F5F5;"));
    ui->addButton->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->deleteButton->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->changeButton->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->employeeButton->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->manufacturerButton->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->productButton->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->invoiceButton->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->firstButton->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->secondButton->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->thirdButton->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->fourthButton->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->fifthButton->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    db = QSqlDatabase::database("db");
    chosentable = nullptr;
    ui->tableView->verticalHeader()->hide();
    ui->tableView->horizontalHeader()->setSectionResizeMode(QHeaderView::ResizeToContents);
}

MainForm::~MainForm()
{
    delete ui;
}

void MainForm::on_quiteAction_triggered()
{
    this->close();
}

void MainForm::on_addButton_clicked()
{
    if(chosentable == "employee")
    {
        employeeForm = new Employee (nullptr);
        employeeForm->show();
    }
    if(chosentable == "manufacturer")
    {
        manufacturerForm = new Manufacturer (nullptr);
        manufacturerForm->show();
    }
    if(chosentable == "invoice")
    {
        invoiceForm = new Invoice (nullptr);
        invoiceForm->show();
    }
    if(chosentable == "product")
    {
        productForm = new Product (nullptr);
        productForm->show();
    }
}

void MainForm::on_changeButton_clicked()
{
    if(ui->tableView->currentIndex().row() == -1)
    {
        QMessageBox::critical(NULL,QObject::tr("ОШИБКА"),"Выберите что изменять");
    }
    else
    {
        if(chosentable == "employee")
        {
            QModelIndex ind = qStandardItemModel->index(ui->tableView->currentIndex().row(), 4);
            employeeForm = new Employee (ind.data().toString());
            employeeForm->show();
        }
        if(chosentable == "manufacturer")
        {
            QModelIndex ind = qStandardItemModel->index(ui->tableView->currentIndex().row(), 0);
            manufacturerForm = new Manufacturer (ind.data().toString());
            manufacturerForm->show();
        }
        if(chosentable == "invoice")
        {
            QModelIndex ind = qStandardItemModel->index(ui->tableView->currentIndex().row(), 0);
            invoiceForm = new Invoice (ind.data().toString());
            invoiceForm->show();
        }
        if(chosentable == "product")
        {
            QModelIndex ind = qStandardItemModel->index(ui->tableView->currentIndex().row(), 0);
            productForm = new Product (ind.data().toString());
            productForm->show();
        }
    }
}

void MainForm::on_deleteButton_clicked()
{
    if(ui->tableView->currentIndex().row() == -1)
    {
        QMessageBox::critical(NULL,QObject::tr("ОШИБКА"),"Выберите что удалять");
    }
    else
    {
        if(chosentable == "employee")
        {
            QModelIndex ind = qStandardItemModel->index(ui->tableView->currentIndex().row(), 4);
            QSqlQuery query;
            query.prepare("SELECT delete_employee(:phone_number)");
            query.bindValue(":phone_number", ind.data().toString());
            query.exec();
        }
        else if(chosentable == "manufacturer")
        {
            QModelIndex ind = qStandardItemModel->index(ui->tableView->currentIndex().row(), 0);
            QSqlQuery query;
            query.prepare("SELECT delete_manufacturer(:name)");
            query.bindValue(":name", ind.data().toString());
            query.exec();
        }
        else if(chosentable == "invoice")
        {
            QModelIndex ind = qStandardItemModel->index(ui->tableView->currentIndex().row(), 0);
            QSqlQuery query;
            query.prepare("SELECT delete_invoice(:id)");
            query.bindValue(":id", ind.data().toString());
            query.exec();
        }
        else if(chosentable == "product")
        {
            QModelIndex ind = qStandardItemModel->index(ui->tableView->currentIndex().row(), 0);
            QSqlQuery query;
            query.prepare("SELECT delete_product(:name)");
            query.bindValue(":name", ind.data().toString());
            query.exec();
        }
    }
}

void MainForm::on_manufacturerButton_clicked()
{
    QSqlQuery query;
    query.exec("SELECT * FROM manufacturer ORDER BY id");
    qStandardItemModel = new QStandardItemModel();
    qStandardItemModel->setHorizontalHeaderLabels(QStringList()<< "название" << "адрес" << "сайт");
    QSqlRecord rec = query.record();
    while (query.next())
    {
        QStandardItem* itemCol1(new QStandardItem(query.value(rec.indexOf("name")).toString()));
        QStandardItem* itemCol2(new QStandardItem(query.value(rec.indexOf("address")).toString()));
        QStandardItem* itemCol3(new QStandardItem(query.value(rec.indexOf("website")).toString()));
        qStandardItemModel->appendRow(QList<QStandardItem*>()<<itemCol1<<itemCol2<<itemCol3);
    }
    ui->tableView->setModel(qStandardItemModel);
    ui->tableView->setSortingEnabled(false);
    chosentable = "manufacturer";
}

void MainForm::on_employeeButton_clicked()
{
    QSqlQuery query;
    query.exec("SELECT employee.full_name, employee_chief.full_name, employee.gender, employee.phone_number, employee.post "
               "FROM employee LEFT JOIN employee_chief on employee.chief = employee_chief.id ORDER BY employee.id");
    qStandardItemModel = new QStandardItemModel();
    qStandardItemModel->setHorizontalHeaderLabels(QStringList()<< "ФИО" << "начальник" << "пол" << "должность" << "телефон");
    QSqlRecord rec = query.record();
    while (query.next())
    {
        QStandardItem* itemCol1(new QStandardItem(query.value(rec.indexOf("full_name")).toString()));
        QStandardItem* itemCol2(new QStandardItem(query.value(rec.indexOf("employee_chief.full_name")).toString()));
        QStandardItem* itemCol3(new QStandardItem(query.value(rec.indexOf("gender")).toString()));
        QStandardItem* itemCol4(new QStandardItem(query.value(rec.indexOf("post")).toString()));
        QStandardItem* itemCol5(new QStandardItem(query.value(rec.indexOf("phone_number")).toString()));
        qStandardItemModel->appendRow(QList<QStandardItem*>()<<itemCol1<<itemCol2<<itemCol3<<itemCol4<<itemCol5);
    }
    ui->tableView->setModel(qStandardItemModel);
    ui->tableView->setSortingEnabled(false);
    chosentable = "employee";
}

void MainForm::on_productButton_clicked()
{
    QSqlQuery query;
    query.exec("SELECT product.name, quantity, measure_unit, manufacturer.name, product.cost "
               "FROM product JOIN manufacturer ON product.manufacturer = manufacturer.id ORDER BY product.id;");
    qStandardItemModel = new QStandardItemModel();
    qStandardItemModel->setHorizontalHeaderLabels(QStringList()<< "название" << "кол-во на складе"
                                           << "единица измерения" << "производитель" << "цена за единицу");
    QSqlRecord rec = query.record();
    while (query.next())
    {
        QStandardItem* itemCol1(new QStandardItem(query.value(rec.indexOf("product.name")).toString()));
        QStandardItem* itemCol2(new QStandardItem(query.value(rec.indexOf("quantity")).toString()));
        QStandardItem* itemCol3(new QStandardItem(query.value(rec.indexOf("measure_unit")).toString()));
        QStandardItem* itemCol4(new QStandardItem(query.value(rec.indexOf("manufacturer.name")).toString()));
        QStandardItem* itemCol5(new QStandardItem(query.value(rec.indexOf("product.cost")).toString()));
        qStandardItemModel->appendRow(QList<QStandardItem*>()<<itemCol1<<itemCol2<<itemCol3<<itemCol4<<itemCol5);
    }
    ui->tableView->setModel(qStandardItemModel);
    ui->tableView->setSortingEnabled(false);
    chosentable = "product";
}

void MainForm::on_invoiceButton_clicked()
{
    QSqlQuery query;
    query.exec("SELECT invoice.id, product.name, invoice.quantity, employee.full_name, invoice.type, invoice.date, invoice.cost "
               "FROM invoice, product, employee WHERE invoice.product = product.id AND invoice.accepted = employee.id "
               "ORDER BY invoice.date;");
    qStandardItemModel = new QStandardItemModel();
    qStandardItemModel->setHorizontalHeaderLabels(QStringList()<< "номер" << "товар" << "кол-во" << "принял" << "тип" << "дата" << "стоимость");
    QSqlRecord rec = query.record();
    while (query.next())
    {
        QStandardItem* itemCol1(new QStandardItem(query.value(rec.indexOf("invoice.id")).toString()));
        QStandardItem* itemCol2(new QStandardItem(query.value(rec.indexOf("product.name")).toString()));
        QStandardItem* itemCol3(new QStandardItem(query.value(rec.indexOf("invoice.quantity")).toString()));
        QStandardItem* itemCol4(new QStandardItem(query.value(rec.indexOf("employee.full_name")).toString()));
        QStandardItem* itemCol5(new QStandardItem(query.value(rec.indexOf("invoice.type")).toString()));
        QStandardItem* itemCol6(new QStandardItem(query.value(rec.indexOf("invoice.date")).toString()));
        QStandardItem* itemCol7(new QStandardItem(query.value(rec.indexOf("invoice.cost")).toString()));
        qStandardItemModel->appendRow(QList<QStandardItem*>()<<itemCol1<<itemCol2<<itemCol3<<itemCol4<<itemCol5<<itemCol6<<itemCol7);
    }
    ui->tableView->setModel(qStandardItemModel);
    ui->tableView->setSortingEnabled(false);
    chosentable = "invoice";
}
void MainForm::on_firstButton_clicked()
{
    QSqlQuery query;
    if (query.exec("SELECT invoice.date, product.name, CASE WHEN invoice.quantity >= 50 THEN 'отлично' "
                   "WHEN invoice.quantity >= 30 THEN 'хорошо' WHEN invoice.quantity >= 10 THEN 'сойдёт' "
                   "ELSE 'надо лучше' END AS количество FROM product, invoice WHERE invoice.product = product.id "
                   "AND invoice.type='приходная' GROUP BY invoice.date, product.name, invoice.quantity "
                   "ORDER BY invoice.date DESC"));
    {
        qStandardItemModel = new QStandardItemModel();
        qStandardItemModel->setHorizontalHeaderLabels(QStringList()<< "дата" << "товар" << "оценка");
        QSqlRecord rec = query.record();
        while (query.next())
        {
            QStandardItem* itemCol1(new QStandardItem(query.value(rec.indexOf("invoice.date")).toString()));
            QStandardItem* itemCol2(new QStandardItem(query.value(rec.indexOf("product.name")).toString()));
            QStandardItem* itemCol3(new QStandardItem(query.value(rec.indexOf("количество")).toString()));
            qStandardItemModel->appendRow(QList<QStandardItem*>()<<itemCol1<<itemCol2<<itemCol3);
        }
        ui->tableView->setModel(qStandardItemModel);
        ui->tableView->setSortingEnabled(false);
        chosentable = "";
    }    
}

void MainForm::on_secondButton_clicked()
{
    QSqlQuery query;
    if (query.exec("SELECT * FROM employee_invoice"))
    {
        qStandardItemModel = new QStandardItemModel();
        qStandardItemModel->setHorizontalHeaderLabels(QStringList()<< "ФИО" << "кол-во");
        QSqlRecord rec = query.record();
        while (query.next())
        {
            QStandardItem* itemCol1(new QStandardItem(query.value(rec.indexOf("full_name")).toString()));
            QStandardItem* itemCol2(new QStandardItem(query.value(rec.indexOf("quantity")).toString()));
            qStandardItemModel->appendRow(QList<QStandardItem*>()<<itemCol1<<itemCol2);
        }
        ui->tableView->setModel(qStandardItemModel);
        ui->tableView->setSortingEnabled(true);
        chosentable = "";
    }
}

void MainForm::on_thirdButton_clicked()
{
    QSqlQuery query;
    if (query.exec("SELECT invoice.id, invoice.quantity, "
                   "(SELECT product.name FROM product WHERE invoice.product=product.id), "
                   "(SELECT employee.full_name FROM employee WHERE employee.id=invoice.accepted), "
                   "(SELECT product.cost*invoice.quantity AS cost FROM product "
                   "WHERE invoice.product=product.id) "
                   "FROM invoice  "
                   "WHERE ((SELECT (product.cost*invoice.quantity) FROM product WHERE invoice.product=product.id) "
                   "> (SELECT AVG(product.cost*invoice.quantity) FROM product, invoice WHERE invoice.product=product.id)) "
                   "ORDER BY cost DESC;"));
    {
        qStandardItemModel = new QStandardItemModel();
        qStandardItemModel->setHorizontalHeaderLabels(QStringList()<< "номер" << "кол-во" << "товар" << "принял" << "стоимость");
        QSqlRecord rec = query.record();
        while (query.next())
        {
            QStandardItem* itemCol1(new QStandardItem(query.value(rec.indexOf("id")).toString()));
            QStandardItem* itemCol2(new QStandardItem(query.value(rec.indexOf("quantity")).toString()));
            QStandardItem* itemCol3(new QStandardItem(query.value(rec.indexOf("name")).toString()));
            QStandardItem* itemCol4(new QStandardItem(query.value(rec.indexOf("full_name")).toString()));
            QStandardItem* itemCol5(new QStandardItem(query.value(rec.indexOf("cost")).toString()));
            qStandardItemModel->appendRow(QList<QStandardItem*>()<<itemCol1<<itemCol2<<itemCol3<<itemCol4<<itemCol5);
        }
        ui->tableView->setModel(qStandardItemModel);
        ui->tableView->setSortingEnabled(false);
        chosentable = "";
    }    
}

void MainForm::on_fourthButton_clicked()
{
    QSqlQuery query;
    if (query.exec("SELECT product.name, MAX(invoice.quantity), employee.full_name "
                   "FROM invoice, product, employee "
                   "WHERE product.id=invoice.product AND employee.id=invoice.accepted "
                   "GROUP BY  product.name, employee.full_name,invoice.type "
                   "HAVING (MAX(invoice.quantity)>='50' AND invoice.type='расходная') ORDER BY max DESC"));
    {
        qStandardItemModel = new QStandardItemModel();
        qStandardItemModel->setHorizontalHeaderLabels(QStringList()<< "товар" << "кол-во" << "ФИО");
        QSqlRecord rec = query.record();
        while (query.next())
        {
            QStandardItem* itemCol1(new QStandardItem(query.value(rec.indexOf("name")).toString()));
            QStandardItem* itemCol2(new QStandardItem(query.value(rec.indexOf("max")).toString()));
            QStandardItem* itemCol3(new QStandardItem(query.value(rec.indexOf("full_name")).toString()));
            qStandardItemModel->appendRow(QList<QStandardItem*>()<<itemCol1<<itemCol2<<itemCol3);
        }
        ui->tableView->setModel(qStandardItemModel);
        ui->tableView->setSortingEnabled(false);
        chosentable = "";
    }    
}

void MainForm::on_fifthButton_clicked()
{
    QSqlQuery query;
    if (query.exec("SELECT product.name "
                   "FROM product "
                   "WHERE product.manufacturer = ANY "
                   "(SELECT manufacturer.id FROM manufacturer WHERE manufacturer.name = 'Молочник')"))
    {
        qStandardItemModel = new QStandardItemModel();
        qStandardItemModel->setHorizontalHeaderLabels(QStringList()<<"товар");
        QSqlRecord rec = query.record();
        while (query.next())
        {
            QStandardItem* itemCol1(new QStandardItem(query.value(rec.indexOf("name")).toString()));
            qStandardItemModel->appendRow(QList<QStandardItem*>()<<itemCol1);
        }
        ui->tableView->setModel(qStandardItemModel);
        ui->tableView->setSortingEnabled(false);
        chosentable = "";
    }    
}
