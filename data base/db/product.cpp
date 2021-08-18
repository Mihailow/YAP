#include "product.h"
#include "ui_product.h"

Product::Product(QString Name) :
    ui(new Ui::Product)
{
    ui->setupUi(this);
    this->setWindowTitle("Товар");
    this->setStyleSheet(QString("color:#F5F5F5; background:#191970;"));
    ui->nameLineEdit->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->quantityLineEdit->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->measure_unitLineEdit->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->manufacturerComboBox->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->costLineEdit->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->pushButton->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    name=Name;
    db = QSqlDatabase::database("db");
    manufacturerBoxModel = new QSqlQueryModel;
    query.prepare("SELECT name FROM manufacturer");
    query.exec();
    manufacturerBoxModel->setQuery(query);
    query.clear();
    ui->manufacturerComboBox->setModel(manufacturerBoxModel);
    if (name!=nullptr)
    {
        query.prepare("SELECT * FROM product where name = :name");
        query.bindValue(":name", name);
        query.exec();
        query.first();
        ui->nameLineEdit->setText(query.value(1).toString());
        ui->quantityLineEdit->setText(query.value(2).toString());
        ui->measure_unitLineEdit->setText(query.value(3).toString());
        ui->manufacturerComboBox->setCurrentText(query.value(4).toString());
        ui->costLineEdit->setText(query.value(5).toString());
        query.clear();
    }
}

Product::~Product()
{
    delete ui;
}

void Product::on_pushButton_clicked()
{
    if(ui->nameLineEdit->text().isEmpty() and
        ui->measure_unitLineEdit->text().isEmpty() and
        ui->manufacturerComboBox->currentText().isEmpty() and
        ui->costLineEdit->text().isEmpty())
    {
        QMessageBox::critical(NULL,QObject::tr("ОШИБКА"),"Есть пустые поля");
    }
    else
    {
        if (name!=nullptr)
        {
            query.prepare("SELECT change_product(:name1, :name, :quantity, :measure_unit, :manufacturer, :cost)");
            query.bindValue(":name1", name);
            query.bindValue(":name", ui->nameLineEdit->text());
            query.bindValue(":quantity", ui->quantityLineEdit->text());
            query.bindValue(":measure_unit", ui->measure_unitLineEdit->text());
            query.bindValue(":manufacturer", ui->manufacturerComboBox->currentText());
            query.bindValue(":cost", ui->costLineEdit->text());
            query.exec();
        }
        else
        {
            query.prepare("SELECT add_product(:name, :quantity, :measure_unit, :manufacturer, :cost)");
            query.bindValue(":name", ui->nameLineEdit->text());
            query.bindValue(":quantity", ui->quantityLineEdit->text());
            query.bindValue(":measure_unit", ui->measure_unitLineEdit->text());
            query.bindValue(":manufacturer", ui->manufacturerComboBox->currentText());
            query.bindValue(":cost", ui->costLineEdit->text());
            query.exec();
        }
    }
    this->close();
}
