#ifndef MANUFACTURER_H
#define MANUFACTURER_H

#include <QWidget>
#include <QSqlDatabase>
#include <QSqlQuery>
#include <QMessageBox>
#include <QSqlError>

namespace Ui {
class Manufacturer;
}

class Manufacturer : public QWidget
{
    Q_OBJECT

public:
    explicit Manufacturer(QString Name);
    ~Manufacturer();

private slots:
    void on_saveButton_clicked();

private:
    Ui::Manufacturer *ui;
    QString name;
    QSqlDatabase db;
    QSqlQuery query;
};

#endif // MANUFACTURER_H
