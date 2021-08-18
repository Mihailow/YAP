#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>

QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
    void reload();

private slots:
    void on_Open_triggered();

    void on_Save_triggered();

    void on_Quit_triggered();

    void on_AddButton_clicked();

    void on_ChangeButton_clicked();

    void on_tableView_clicked(const QModelIndex &index);

    void on_DeleteButton_clicked();

private:
    Ui::MainWindow *ui;
};
#endif // MAINWINDOW_H
