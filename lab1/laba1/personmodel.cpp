#include "personmodel.h"

PersonModel::PersonModel(QObject *parent) : QAbstractTableModel(parent)
{
   };
int PersonModel::rowCount( const QModelIndex& parent) const
{
    Q_UNUSED(parent)
    return allPerson.size();
};

int PersonModel::columnCount( const QModelIndex& parent) const
{
    Q_UNUSED(parent)
    return 5;
};

QVariant PersonModel::data( const QModelIndex& index, int role) const
{
    if(!index.isValid() || role != Qt::DisplayRole)
    {
        return QVariant();
    }
    if(index.column() == 0)
        return allPerson[index.row()].getName();
    if(index.column() == 1)
        return allPerson[index.row()].getSurname();
    if(index.column() == 2)
        return allPerson[index.row()].getAge();
    if(index.column() == 3)
        return allPerson[index.row()].getWeight();
    if(index.column() == 4)
        return allPerson[index.row()].getHeight();
    return QVariant();
};

QVariant PersonModel::headerData( int section, Qt::Orientation orientation, int role) const
{
    if(role == Qt::DisplayRole && orientation == Qt::Horizontal)
    {
        if(section == 0)
            return QString("Имя");
        else if (section == 1)
            return QString("Фамилия");
        else if (section == 2)
            return QString("Возраст");
        else if (section == 3)
            return QString("Вес");
        else if (section == 4)
            return QString("Рост");
    }
    return QVariant();
};

void PersonModel::ReloadTable(QVector <Person> a)
{
    allPerson.clear();
    allPerson = a;
};
