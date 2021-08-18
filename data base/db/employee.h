#ifndef EMPLOYEE_H
#define EMPLOYEE_H

#include <QWidget>
#include <QSqlDatabase>
#include <QSqlQuery>
#include <QMessageBox>
#include <QSqlQueryModel>
#include <QSqlError>
#include <QtSql>

namespace Ui {
class Employee;
}

class Employee : public QWidget
{
    Q_OBJECT

public:
    explicit Employee(QString Phone_number);
    ~Employee();

private slots:
    void on_saveButton_clicked();

private:
    Ui::Employee *ui;
    QString phone_number;
    QSqlDatabase db;
    QSqlQuery query;
};

#endif // EMPLOYEE_H
