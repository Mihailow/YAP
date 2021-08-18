#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    setWindowTitle("Чат");
    ui->msgEdit->setReadOnly(true);
    udpSocket = new QUdpSocket(this);
    udpSocket->bind(5433);
    connect(udpSocket, SIGNAL(readyRead()), SLOT(DisplayMessages()));

    QSqlDatabase db = QSqlDatabase::addDatabase("QPSQL");
    db.setHostName("localhost");
    db.setDatabaseName("practice3");
    db.setUserName("postgres");
    db.setPassword("postgres");
    if (!db.open())
        QMessageBox::critical(NULL,QObject::tr("Ошибка"),db.lastError().text());
}

MainWindow::~MainWindow()
{
    delete ui;
}


void MainWindow::on_sendMsgButton_clicked()
{
    if((ui->msgLine->text().isEmpty() == false) and (auth == true))
    {
        QByteArray byteArray;
        QDataStream out(&byteArray, QIODevice::WriteOnly);
        out.setVersion(QDataStream::Qt_DefaultCompiledVersion);
        QString msg = ui->nameLine->text() + ": " + ui->msgLine->text() + "\n" + QDateTime::currentDateTime().toString();
        out << msg;
        udpSocket->writeDatagram(byteArray, QHostAddress::LocalHost, 5432);
        InsertMessage();
        ui->msgEdit->moveCursor(QTextCursor::End);
        ui->msgEdit->insertPlainText(msg + "\n");
        ui->msgLine->clear();
    }
}

void MainWindow::DisplayMessages()
{
    QByteArray byteArray;
    do
    {
        byteArray.resize(udpSocket->pendingDatagramSize());
        udpSocket->readDatagram(byteArray.data(), byteArray.size());
    }
    while (udpSocket->hasPendingDatagrams());

    QDataStream in(&byteArray,QIODevice::ReadOnly);
    in.setVersion(QDataStream::Qt_DefaultCompiledVersion);
    QString str;
    in >> str;
    ui->msgEdit->moveCursor(QTextCursor::End);
    ui->msgEdit->insertPlainText(str + "\n");
}

void MainWindow::on_authButton_clicked()
{
    if(ui->nameLine->text().isEmpty() == false)
    {
        ui->nameLine->setReadOnly(true);
        auth = true;
    }
}


void MainWindow::on_showDbButton_clicked()
{
    QSqlQuery query;
    if (query.exec("SELECT * FROM Msg"))
    {
        qStandardItemModel = new QStandardItemModel();
        qStandardItemModel->setHorizontalHeaderLabels(QStringList()<< "id" << "name" << "message" << "time");

        QSqlRecord rec = query.record();
        QString id, name, message, time;

        while (query.next())
        {
            id = query.value(rec.indexOf("id")).toString();
            name = query.value(rec.indexOf("name")).toString();
            message = query.value(rec.indexOf("message")).toString();
            time = query.value(rec.indexOf("time")).toString();

            QStandardItem* itemCol1(new QStandardItem(id));
            QStandardItem* itemCol2(new QStandardItem(name));
            QStandardItem* itemCol3(new QStandardItem(message));
            QStandardItem* itemCol4(new QStandardItem(time));

            qStandardItemModel->appendRow(QList<QStandardItem*>()<<itemCol1<<itemCol2<<itemCol3<<itemCol4);
        }
        ui->tableView->setModel(qStandardItemModel);
    }
}

void MainWindow::InsertMessage()
{

    QSqlQuery query;
    query.prepare("INSERT INTO Msg (name, message, time) "
            "VALUES (:name, :message, :time)");
    query.bindValue(":name", ui->nameLine->text());
    query.bindValue(":message", ui->msgLine->text());
    query.bindValue(":time", QDateTime::currentDateTime().toString());
    query.exec();

}
