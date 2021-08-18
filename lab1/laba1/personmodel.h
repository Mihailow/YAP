#ifndef PERSONMODEL_H
#define PERSONMODEL_H
#include "person.h"

#include <QAbstractTableModel>
#include <QObject>


class PersonModel : public QAbstractTableModel
{
    Q_OBJECT
public:
    PersonModel(QObject *parent = 0);
    int rowCount( const QModelIndex& parent = QModelIndex()) const Q_DECL_OVERRIDE;
    int columnCount( const QModelIndex& parent = QModelIndex()) const Q_DECL_OVERRIDE;
    QVariant data( const QModelIndex& index, int role = Qt::DisplayRole) const Q_DECL_OVERRIDE;
    QVariant headerData( int section, Qt::Orientation orientation, int role = Qt::DisplayRole) const Q_DECL_OVERRIDE;
    void ReloadTable(QVector <Person> a);
private:
    QVector <Person> allPerson;
};

#endif // PERSONMODEL_H
