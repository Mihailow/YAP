#ifndef INVOICE_H
#define INVOICE_H

#include <QWidget>
#include <QSqlDatabase>
#include <QSqlQuery>
#include <QMessageBox>
#include <QSqlQueryModel>
#include <QSqlError>

namespace Ui {
class Invoice;
}

class Invoice : public QWidget
{
    Q_OBJECT

public:
    explicit Invoice(QString Id);
    ~Invoice();

private slots:
    void on_SaveButton_clicked();

private:
    Ui::Invoice *ui;
    QString id;
    QSqlDatabase db;
    QSqlQuery query;
    QSqlQueryModel* productBoxModel;
    QSqlQueryModel* acceptedBoxModel;
};

#endif // INVOICE_H
