#include "manufacturer.h"
#include "ui_manufacturer.h"

Manufacturer::Manufacturer(QString Name) :
    ui(new Ui::Manufacturer)
{
    ui->setupUi(this);
    this->setWindowTitle("Поставщик");
    this->setStyleSheet(QString("color:#F5F5F5; background:#191970;"));
    ui->nameLineEdit->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->addressLineEdit->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->websiteLineEdit->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->saveButton->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    name=Name;
    db = QSqlDatabase::database("db");
    if (name!=nullptr)
    {
        query.prepare("SELECT * FROM manufacturer where name = :name");
        query.bindValue(":name", name);
        query.exec();
        query.first();
        ui->nameLineEdit->setText(query.value(1).toString());
        ui->addressLineEdit->setText(query.value(2).toString());
        ui->websiteLineEdit->setText(query.value(3).toString());
        query.clear();
    }
}

Manufacturer::~Manufacturer()
{
    delete ui;
}

void Manufacturer::on_saveButton_clicked()
{
    if(ui->nameLineEdit->text().isEmpty() and
        ui->addressLineEdit->text().isEmpty() and
        ui->websiteLineEdit->text().isEmpty())
    {
        QMessageBox::critical(NULL,QObject::tr("ОШИБКА"),"Есть пустые поля");
    }
    else
    {
        if (name!=nullptr)
        {
            query.prepare("SELECT change_manufacturer "
                    "(:name1, :name2, :address, :website)");
            query.bindValue(":name1", name);
            query.bindValue(":name2", ui->nameLineEdit->text());
            query.bindValue(":address", ui->addressLineEdit->text());
            query.bindValue(":website", ui->websiteLineEdit->text());
            query.exec();
        }
        else
        {
            query.prepare("SELECT add_manufacturer "
                    "(:name, :address, :website)");
            query.bindValue(":name", ui->nameLineEdit->text());
            query.bindValue(":address", ui->addressLineEdit->text());
            query.bindValue(":website", ui->websiteLineEdit->text());
            query.exec();
        }
    }
    this->close();
}
