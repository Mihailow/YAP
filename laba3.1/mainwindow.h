#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>

#include <QUdpSocket>
#include <QByteArray>
#include <QSqlDatabase>
#include <QMessageBox>
#include <QSqlQuery>
#include <QSqlError>
#include <QException>
#include <QtSql>
#include <QDateTime>
#include <QStandardItemModel>
#include <QStandardItem>

QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
    void InsertMessage();

private slots:
    void on_sendMsgButton_clicked();

    void DisplayMessages();

    void on_authButton_clicked();

    void on_showDbButton_clicked();

private:
    Ui::MainWindow *ui;
    QUdpSocket* udpSocket;
    QSqlDatabase db;
    QStandardItemModel* qStandardItemModel;
    bool auth = 0;
};
#endif // MAINWINDOW_H
