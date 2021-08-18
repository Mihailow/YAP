#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QFileDialog>
#include "QStandardItemModel"
#include "QStandardItem"
#include "person.h"
#include "personmodel.h"
#include <QXmlStreamWriter>
#include <QXmlStreamReader>
#include <QMessageBox>

QVector <Person> person;
QString filename;


MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    ui->tableView->horizontalHeader()->setVisible(true);
    ui->tableView->show();
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_Open_triggered()
{
    filename = QFileDialog::getOpenFileName(0,QObject::tr("Укажите файл базы данных"),QDir::homePath(), QObject::tr("Файл SQLite (*.xml);;Все файлы (*.*)"));

    QString name, surname, age, weight, height;

    QFile file(filename);

    if (!file.open(QFile::ReadOnly | QFile::Text))
    {
        qDebug() << "Ошибка";
    }
    else
    {
        QXmlStreamReader xmlReader;
        xmlReader.setDevice(&file);
        xmlReader.readNextStartElement();
        while( !xmlReader.atEnd() )
        {
            if( xmlReader.readNextStartElement() )
            {
                name =  xmlReader.attributes().value("name").toString();
                surname =  xmlReader.attributes().value("surname").toString();
                age =  xmlReader.attributes().value("age").toString();
                weight =  xmlReader.attributes().value("weight").toString();
                height =  xmlReader.attributes().value("height").toString();
                person.push_back(Person(name, surname, age, weight, height));
            }
        }
        file.close();
    }
    reload();
}

void MainWindow::reload()
{
    PersonModel* PersonTable = new PersonModel(this);
    PersonTable->ReloadTable(person);
    ui->tableView->setModel(PersonTable);
}

void MainWindow::on_Save_triggered()
{
    QFile file(filename);
        file.open(QIODevice::WriteOnly);

        QXmlStreamWriter xmlWriter(&file);
        xmlWriter.setAutoFormatting(true);
        xmlWriter.writeStartDocument();

        xmlWriter.writeStartElement("Persons");
        for (int i=0; i<person.size(); i++)
        {
            xmlWriter.writeStartElement("person"+QString::number(i));
            xmlWriter.writeAttribute("name", person[i].getName());
            xmlWriter.writeAttribute("surname", person[i].getSurname());
            xmlWriter.writeAttribute("age", person[i].getAge());
            xmlWriter.writeAttribute("weight", person[i].getWeight());
            xmlWriter.writeAttribute("height", person[i].getHeight());
            xmlWriter.writeEndElement();
        }
        xmlWriter.writeEndElement();
        xmlWriter.writeEndDocument();
        file.close();
}

void MainWindow::on_Quit_triggered()
{
    QApplication::quit();
}

void MainWindow::on_AddButton_clicked()
{
    if(ui->NameLine->text()!=nullptr and ui->SurnameLine->text()!=nullptr and ui->AgeLine->text()!=nullptr and ui->HeightLine->text()!=nullptr and ui->WeightLine->text()!=nullptr)
    {
        person.append(Person(ui->NameLine->text(), ui->SurnameLine->text(), ui->AgeLine->text(), ui->HeightLine->text(), ui->WeightLine->text()));
        ui->NameLine->clear();
        ui->SurnameLine->clear();
        ui->AgeLine->clear();
        ui->HeightLine->clear();
        ui->WeightLine->clear();
    }
    else
        QMessageBox::critical(NULL,QObject::tr("Ошибка"),tr("Есть пустые ячейки"));
    reload();
}

void MainWindow::on_ChangeButton_clicked()
{    
    if(ui->TextLine->text()!=nullptr)
    {
        if(ui->tableView->currentIndex().column() == 0)
            person[ui->tableView->currentIndex().row()].setName(ui->TextLine->text());
        if(ui->tableView->currentIndex().column() == 1)
            person[ui->tableView->currentIndex().row()].setSurname(ui->TextLine->text());
        if(ui->tableView->currentIndex().column() == 2)
            person[ui->tableView->currentIndex().row()].setAge(ui->TextLine->text());
        if(ui->tableView->currentIndex().column() == 3)
            person[ui->tableView->currentIndex().row()].setWeight(ui->TextLine->text());
        if(ui->tableView->currentIndex().column() == 4)
            person[ui->tableView->currentIndex().row()].setHeight(ui->TextLine->text());
    }
    else
        QMessageBox::critical(NULL,QObject::tr("Ошибка"),tr("Есть пустые ячейки"));
    reload();
}

void MainWindow::on_tableView_clicked(const QModelIndex &index)
{
    ui->TextLine->setText(ui->tableView->model()->data(ui->tableView->currentIndex()).toString());
}

void MainWindow::on_DeleteButton_clicked()
{
    person.remove(ui->tableView->currentIndex().row());
    reload();
}
