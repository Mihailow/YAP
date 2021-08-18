#include "invoice.h"
#include "ui_invoice.h"

Invoice::Invoice(QString Id) :
    ui(new Ui::Invoice)
{
    ui->setupUi(this);
    this->setWindowTitle("Накладная");
    this->setStyleSheet(QString("color:#F5F5F5; background:#191970;"));
    ui->productComboBox->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->quantityLineEdit->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->acceptedComboBox->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->typeComboBox->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->dateLineEdit->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->SaveButton->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    id=Id;
    db = QSqlDatabase::database("db");
    productBoxModel = new QSqlQueryModel;
    query.prepare("SELECT name FROM product");
    query.exec();
    productBoxModel->setQuery(query);
    query.clear();
    ui->productComboBox->setModel(productBoxModel);
    acceptedBoxModel = new QSqlQueryModel;
    query.prepare("SELECT full_name FROM employee");
    query.exec();
    acceptedBoxModel->setQuery(query);
    query.clear();
    ui->acceptedComboBox->setModel(acceptedBoxModel);
    ui->typeComboBox->addItem("расходная");
    ui->typeComboBox->addItem("приходная");
    if (id!=nullptr)
    {
        query.prepare("SELECT product.name, invoice.quantity, employee.full_name, invoice.type, invoice.date "
                   "FROM invoice, product, employee WHERE invoice.product = product.id AND invoice.accepted = employee.id "
                   "WHERE id = :id ORDER BY invoice.date;");;
        query.bindValue(":id", id);
        query.exec();
        query.first();
        ui->productComboBox->setCurrentText(query.value(0).toString());
        ui->quantityLineEdit->setText(query.value(1).toString());
        ui->acceptedComboBox->setCurrentText(query.value(2).toString());
        ui->typeComboBox->setCurrentText(query.value(3).toString());
        ui->dateLineEdit->setText(query.value(4).toString());
    }
}

Invoice::~Invoice()
{
    delete ui;
}

void Invoice::on_SaveButton_clicked()
{
    if(ui->productComboBox->currentText().isEmpty() and
        ui->quantityLineEdit->text().isEmpty() and
        ui->acceptedComboBox->currentText().isEmpty() and
        ui->typeComboBox->currentText().isEmpty() and
        ui->dateLineEdit->text().isEmpty())
    {
        QMessageBox::critical(NULL,QObject::tr("ОШИБКА"),"Есть пустые поля");
    }
    else
    {
        if (id!=nullptr)
        {
            query.prepare("SELECT change_invoice(:id, :product, :quantity, :accepted, :type, :date)");
            query.bindValue(":id", id);
            query.bindValue(":product", ui->productComboBox->currentText());
            query.bindValue(":quantity", ui->quantityLineEdit->text());
            query.bindValue(":accepted", ui->acceptedComboBox->currentText());
            query.bindValue(":type", ui->typeComboBox->currentText());
            query.bindValue(":date", ui->dateLineEdit->text());
            query.exec();
        }
        else
        {
            query.prepare("SELECT add_invoice(:product, :quantity, :accepted, :type, :date)");
            query.bindValue(":product", ui->productComboBox->currentText());
            query.bindValue(":quantity", ui->quantityLineEdit->text());
            query.bindValue(":accepted", ui->acceptedComboBox->currentText());
            query.bindValue(":type", ui->typeComboBox->currentText());
            query.bindValue(":date", ui->dateLineEdit->text());
            query.exec();
        }
    }
    this->close();
}
