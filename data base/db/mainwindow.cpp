#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    setWindowTitle("Вход");
    this->setStyleSheet(QString("color:#F5F5F5; background:#191970;"));
    ui->enterButton->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->nameLineEdit->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->passwordLineEdit->setStyleSheet(QString("color:#191970; background:#FFC0CB;"));
    ui->passwordLineEdit->setEchoMode(QLineEdit::Password);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_enterButton_clicked()
{
    if((ui->nameLineEdit->text().isEmpty()) and (ui->passwordLineEdit->text().isEmpty()))
    {
        QMessageBox::critical(NULL,QObject::tr("Ошибка"),"Есть пустые поля");
    }
    else
    {
        db = QSqlDatabase::addDatabase("QPSQL");
        db.setHostName("localhost");
        db.setDatabaseName("db");
        db.setUserName(ui->nameLineEdit->text());
        db.setPassword(ui->passwordLineEdit->text());
        if (!db.open())
        {
            QMessageBox::critical(NULL,QObject::tr("Ошибка"),db.lastError().text());
        }
        else
        {
            mainform = new MainForm;
            mainform->show();
            this->close();
        }
    }
}
