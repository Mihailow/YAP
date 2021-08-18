#include "person.h"
#include <QDebug>

QString Person::getName() const
{
    return name;
}

void Person::setName(const QString &value)
{
    name = value;
}

QString Person::getSurname() const
{
    return surname;
}

void Person::setSurname(const QString &value)
{
    surname = value;
}

QString Person::getAge() const
{
    return age;
}

void Person::setAge(const QString &value)
{
    age = value;
}

QString Person::getWeight() const
{
    return weight;
}

void Person::setWeight(const QString &value)
{
    weight = value;
}

QString Person::getHeight() const
{
    return height;
}

void Person::setHeight(const QString &value)
{
    height = value;
}

Person::Person(QString _name, QString _surname, QString _age, QString _weight, QString _height)
{
    name=_name;
    surname=_surname;
    age=_age;
    weight=_weight;
    height=_height;
}
