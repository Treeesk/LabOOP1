using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MySet<T>
{
    private readonly HashSet<T> data; //readonly тк. после создания никак не изменяем множество
    public MySet(IEnumerable<T> collection)
    {
        data = new HashSet<T>(collection); // автоматически убирает дубликаты
    }
    private MySet(HashSet<T> set)
    {
        // чтобы быстрее создавать из HashSet другие HashSet
        data = new HashSet<T>(set);
    }

    public static MySet<T> operator |(MySet<T> a, MySet<T> b)
    {
        var result = new HashSet<T>(a.data);
        result.UnionWith(b.data);
        return new MySet<T>(result);
    }

    public static MySet<T> operator -(MySet<T> a, MySet<T> b)
    {
        // из множества a вычитаются все элементы множества b 
        var result = new HashSet<T>(a.data);
        result.ExceptWith(b.data);
        return new MySet<T>(result);
    }

    public static MySet<T> operator &(MySet<T> a, MySet<T> b)
    {
        var result = new HashSet<T>(a.data);
        result.IntersectWith(b.data);
        return new MySet<T>(result);
    }

    public static MySet<T> operator /(MySet<T> a, MySet<T> b)
    {
        // элементы только множества a и b, но не их пересечение
        var result = new HashSet<T>(a.data);
        result.SymmetricExceptWith(b.data);
        return new MySet<T>(result);
    }

    public static bool operator ==(MySet<T> a, MySet<T> b)
    {
        if (ReferenceEquals(a, b)) return true; // являются ли оба объекта одним и тем же в памяти
        if (a is null || b is null) return false;

        return a.data.SetEquals(b.data); // проверка каждого элемента
    }

    public static bool operator !=(MySet<T> a, MySet<T> b)
    {
        return !(a == b);
    }

    public override string ToString()
    {
        return "{" + string.Join(", ", data) + "}";
    }
}

