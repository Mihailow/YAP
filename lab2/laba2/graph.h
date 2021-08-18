#ifndef GRAPH_H
#define GRAPH_H
#include <QString>
#include <QVector>


class Graph
{
public:
    Graph(QString _name, QVector <QString> _connection);
    const QString &getName() const;
    void setName(const QString &newName);

    const QVector<QString> &getConnection() const;
    void setConnection(const QVector<QString> &newConnection);

private:
    QString name;
    QVector <QString> connection;
};

#endif // GRAPH_H
