#include "graph.h"
#include <QDebug>

Graph::Graph(QString _name, QVector <QString> _connection)
{
    name=_name;
    connection=_connection;
}

const QString &Graph::getName() const
{
    return name;
}

void Graph::setName(const QString &newName)
{
    name = newName;
}

const QVector<QString> &Graph::getConnection() const
{
    return connection;
}

void Graph::setConnection(const QVector<QString> &newConnection)
{
    connection = newConnection;
}
