#ifndef PERSON_H
#define PERSON_H
#include <QString>


class Person
{
private:
    QString name;
    QString surname;
    QString age;
    QString weight;
    QString height;
public:
    Person(QString _name, QString _surname, QString _age, QString _weight, QString _height);
    QString getName() const;
    void setName(const QString &value);
    QString getSurname() const;
    void setSurname(const QString &value);
    QString getAge() const;
    void setAge(const QString &value);
    QString getWeight() const;
    void setWeight(const QString &value);
    QString getHeight() const;
    void setHeight(const QString &value);
};

#endif // PERSON_H
