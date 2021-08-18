#ifndef PRODUCT_H
#define PRODUCT_H

#include <QWidget>
#include <QSqlDatabase>
#include <QSqlQuery>
#include <QMessageBox>
#include <QSqlQueryModel>
#include <QSqlError>

namespace Ui {
class Product;
}

class Product : public QWidget
{
    Q_OBJECT

public:
    explicit Product(QString Name);
    ~Product();

private slots:
    void on_pushButton_clicked();

private:
    Ui::Product *ui;
    QString name;
    QSqlDatabase db;
    QSqlQuery query;
    QSqlQueryModel* manufacturerBoxModel;
};

#endif // PRODUCT_H
