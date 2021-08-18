#include "mainwindow.h"
//#include <QFile>
//#include <QTextStream>
//#include <QDebug>
#include <QApplication>

//#include "person.h"

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    MainWindow w;
    w.show();
    return a.exec();
}
