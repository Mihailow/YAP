#include "mainwindow.h"
#include "ui_mainwindow.h"

#include "graph.h"
#include <QString>
#include <QVector>
#include <QFile>
#include <QXmlStreamReader>
#include <QFileDialog>

QVector <Graph> graph;

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::paintEvent(QPaintEvent *)
{
    QPainter painter;
    painter.begin(this);
    painter.translate(width()/2, height()/2);

    for (int n=0; n<graph.size(); n++)
    {
        painter.save();
        painter.rotate((360/graph.size())*n);
        painter.translate(0,200);
        painter.drawEllipse(-40, -40, 80, 80);
        painter.rotate((-360/graph.size())*n);
        painter.drawText(0, 0, graph[n].getName());
        painter.restore();
    }

    double alpha, a;
    for (int n=0; n<graph.size(); n++)
    {
        painter.save();
        painter.rotate((360/graph.size())*n);
        painter.translate(0,160);
        painter.rotate(270);
        for (int j=0; j<graph[n].getConnection().size(); j++)
        {
            for (int k=n; k<graph.size(); k++)
            {
                if(graph[n].getConnection()[j] == graph[k].getName())
                {
                    alpha=180-360/graph.size()/2*(k-n);
                    a = sqrt(160*160*2*(1-cos(360/graph.size()*(k-n)*3.14/180)));
                    painter.rotate(-alpha);
                    painter.drawLine(0, 0, 0, a);
                    painter.rotate(alpha);
                }
            }
        }
        painter.restore();
    }

    painter.end();
}

void MainWindow::on_action_triggered()
{
    QString filename = QFileDialog::getOpenFileName(0,QObject::tr("Укажите файл базы данных"),QDir::homePath(), QObject::tr("Файл SQLite (*.xml);;Все файлы (*.*)"));
    QString name;
    QVector <QString> connection;
    int j = 0;
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
                while (1)
                {
                    if (xmlReader.attributes().value("connection"+QString::number(j)).toString() == nullptr)
                    {
                        j = 0;
                        break;
                    }
                    else
                    {
                        connection.push_back(QString (xmlReader.attributes().value("connection"+QString::number(j)).toString()));
                        j++;
                    }
                }
                graph.push_back(Graph(name, connection));
                connection.clear();
            }
        }
        file.close();
    }
}
