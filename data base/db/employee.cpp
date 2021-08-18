#include "employee.h"
#include "ui_employee.h"

Employee::Employee(QString Phone_number) :
    ui(new Ui::Employee)
{
    ui->setupUi(this);
    this->setWindowTitle("Работник");
    this->setStyleSheet(QString("color:#F5F5F5; background:#191970;"));
    ui->full_nameLineEdit->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->chiefComboBox->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->genderComboBox->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->phone_numberLineEdit->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->postLineEdit->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->saveButton->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    phone_number=Phone_number;
    db = QSqlDatabase::database("db");
    ui->genderComboBox->addItem("муж");
    ui->genderComboBox->addItem("жен");
    if (phone_number!=nullptr)
    {
        query.prepare("SELECT full_name FROM employee WHERE phone_number != :phone_number");
        query.bindValue(":phone_number", phone_number);
        query.exec();
        QSqlRecord rec = query.record();
        while (query.next())
        {
            ui->chiefComboBox->addItem(query.value(rec.indexOf("full_name")).toString());
        }
        ui->chiefComboBox->addItem("");
        query.prepare("SELECT employee.full_name, employee_chief.full_name, employee.gender, employee.post, employee.phone_number "
                      "FROM employee LEFT JOIN employee_chief on employee.chief = employee_chief.id "
                      "WHERE phone_number = :phone_number ORDER BY employee.id");
        query.bindValue(":phone_number", phone_number);
        query.exec();
        query.first();
        ui->full_nameLineEdit->setText(query.value(0).toString());
        ui->chiefComboBox->setCurrentText(query.value(1).toString());
        ui->genderComboBox->setCurrentText(query.value(2).toString());
        ui->postLineEdit->setText(query.value(3).toString());
        ui->phone_numberLineEdit->setText(query.value(4).toString());
        query.clear();
    }
    else
    {
        query.exec("SELECT full_name FROM employee");
        QSqlRecord rec = query.record();
        while (query.next())
        {
            ui->chiefComboBox->addItem(query.value(rec.indexOf("full_name")).toString());
        }
        ui->chiefComboBox->addItem("");
        query.clear();
        ui->chiefComboBox->setCurrentText("");
    }
}

Employee::~Employee()
{
    delete ui;
}

void Employee::on_saveButton_clicked()
{
    if(ui->full_nameLineEdit->text().isEmpty() and
        ui->phone_numberLineEdit->text().isEmpty() and
        ui->postLineEdit->text().isEmpty())
    {
        QMessageBox::critical(NULL,QObject::tr("ОШИБКА"),"Есть пустые поля");
    }
    else
    {
        if (phone_number!=nullptr)
        {
            query.prepare("SELECT change_employee(:phone_number1, :full_name, :chief, :gender, :phone_number, :post)");
            query.bindValue(":phone_number1", phone_number);
            query.bindValue(":full_name", ui->full_nameLineEdit->text());
            query.bindValue(":chief", ui->chiefComboBox->currentText());
            query.bindValue(":gender", ui->genderComboBox->currentText());
            query.bindValue(":phone_number", ui->phone_numberLineEdit->text());
            query.bindValue(":post", ui->postLineEdit->text());
            query.exec();
        }
        else
        {
            query.prepare("SELECT add_employee(:full_name, :chief, :gender, :phone_number, :post)");
            query.bindValue(":full_name", ui->full_nameLineEdit->text());
            query.bindValue(":chief", ui->chiefComboBox->currentText());
            query.bindValue(":gender", ui->genderComboBox->currentText());
            query.bindValue(":phone_number", ui->phone_numberLineEdit->text());
            query.bindValue(":post", ui->postLineEdit->text());
            query.exec();
        }
    }
    this->close();
}
