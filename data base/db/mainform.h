#ifndef MAINFORM_H
#define MAINFORM_H

#include <QMainWindow>
#include <employee.h>
#include <invoice.h>
#include <manufacturer.h>
#include <product.h>
#include <QStandardItemModel>
#include <QStandardItem>
#include <QSqlDatabase>
#include <QSqlQuery>
#include <QSqlError>
#include <QtSql>
#include <QMessageBox>

namespace Ui {
class MainForm;
}

class MainForm : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainForm(QWidget *parent = nullptr);
    ~MainForm();

private slots:
    void on_quiteAction_triggered();
    void on_addButton_clicked();
    void on_changeButton_clicked();
    void on_deleteButton_clicked();
    void on_manufacturerButton_clicked();
    void on_employeeButton_clicked();
    void on_productButton_clicked();
    void on_invoiceButton_clicked();
    void on_firstButton_clicked();
    void on_secondButton_clicked();
    void on_thirdButton_clicked();
    void on_fourthButton_clicked();
    void on_fifthButton_clicked();

private:
    Ui::MainForm *ui;
    QString chosentable;
    Employee *employeeForm;
    Invoice *invoiceForm;
    Manufacturer *manufacturerForm;
    Product *productForm;
    QSqlDatabase db;
    QStandardItemModel *qStandardItemModel;
};

#endif // MAINFORM_H
