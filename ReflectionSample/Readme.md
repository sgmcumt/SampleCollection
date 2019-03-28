## 概念
反射（Reflection）是.Net中获取运行时类型信息的一种方式。通过反射，我们可以在运行时获得.NET中的每一个类型的成员，这些类型包括类、结构、委托和枚举。有了反射，即可对每一个类型了如指掌。只要获得了构造函数的信息，即可直接创建对象，即使这个对象的类型在编译时还不知道。

## 反射的基本使用

### 基于反射创建对象

在用反射创建对象之前，首先需要加载程序集，加载程序集有以下三种方法：
```
// 1. 程序集在运行程序所在目录，直接通过程序集文件名称加载
Assembly ass1 = Assembly.Load("ReflectionSample");

// 2.程序集在运行程序所在目录，也可以加上程序集名称的扩展名
Assembly ass2 = Assembly.LoadFrom("ReflectionSample.exe");

// 3. 通过完整路径加载程序集
string path = System.IO.Directory.GetCurrentDirectory() + "\\ReflectionSample.exe";
Assembly ass3 = Assembly.LoadFile(path);
```
加载完程序集后，可以通过`GetTypes()`获取当前程序集可用的类型：
```
Type[] types = ass1.GetTypes();//获取当前程序集中所能找到的可用类型
foreach (Type item in types)
{
    Console.WriteLine("类型成员：" + item.Name);
    Console.WriteLine("类型名称：" + item); //类的完全限定名
    Console.WriteLine("----------------------------------------------------------------");
}
```
加载完程序集后，就可以创建对象了：
```
// 1. 方法一 ：通过激活器和类型创建对象
Type studentType = ass1.GetType("ReflectionSample.Student");
Student student1 = (Student)Activator.CreateInstance(studentType);

//2. 通过程序集里面的方法创建(使用类型完全限定名的时候，是区分大小写的)
Student student2 = (Student)Assembly.Load("ReflectionSample").CreateInstance("ReflectionSample.Student");
```

### 反射中构造方法的使用

对象中往往有构造方法，在创建完对象用，可通过以下方法使用构造方法：
```
Type type = Assembly.Load("ReflectionSample").GetType("ReflectionSample.Student");
//通过构造方法创建对象
object student3 = Activator.CreateInstance(type);//调用的是无参数的构造方法
object student4= Activator.CreateInstance(type, new object[] { "王小明" });//调用一个参数的构造方法
object student5 = Activator.CreateInstance(type, new object[] { "王小明", 15 }); //调用两个参数的构造方法
```
有的时候，构造方法是私有的，可以通过下面的方法获取：
```
Type teacher = Assembly.Load("ReflectionSample").GetType("ReflectionSample.Teacher");
Teacher teacher1 = (Teacher)Activator.CreateInstance(teacher, true);//true表示可以匹配私有构造方法
teacher1.Introduce();
```

## 基于反射创建泛型类对象
```
//可以通过ILDASM观察泛型类的生成
Type genericInstructorType = Assembly.Load("ReflectionSample").
    GetType("ReflectionSample.Counsellor`2");

// 指定泛型类型
Type commonType = genericInstructorType.MakeGenericType(new Type[] { typeof(string), typeof(string) });

var instructor = (Counsellor<string, string>)Activator.CreateInstance(commonType);
instructor.Introduce("计算机系", "辅导员");
```

## 基于反射调用方法（公共方法、私有方法、静态方法和泛型方法）
```
Type presidentType = Assembly.Load("ReflectionSample").GetType("ReflectionSample.President");
object president = Activator.CreateInstance(presidentType);
Console.WriteLine("*************President对象的公共方法*********************");
foreach (MethodInfo item in presidentType.GetMethods())
{
    Console.WriteLine(item.Name);
}
Console.WriteLine("\r\n-------------------调用公共方法-------------------------------");
//通过方法名获取方法
MethodInfo method0 = presidentType.GetMethod("Teach");
method0.Invoke(president, null);//调用无参数的方法使用null
// 如果是方法重载，则必须显示声明参数类型
MethodInfo method = presidentType.GetMethod("Introduce",new Type[] { });
method.Invoke(president, null);//调用无参数的方法使用null
MethodInfo method1 = presidentType.GetMethod("Introduce", new Type[] { typeof(string) });
method1.Invoke(president, new object[] { "实验小学" });//调用一个参数的方法

MethodInfo method2 = presidentType.GetMethod("Introduce", new Type[] { typeof(string), typeof(int) });
method2.Invoke(president, new object[] { "实验小学",10 });//调用2个参数的方法

Console.WriteLine("\r\n----------------------调用私有方法-------------------------------");
MethodInfo method3 = presidentType.GetMethod("Secret", BindingFlags.Instance | BindingFlags.NonPublic);
method3.Invoke(president, null);

Console.WriteLine("\r\n------------------------调用静态方法-----------------------------");
MethodInfo method4 = presidentType.GetMethod("Work", new Type[] { typeof(string) });
method4.Invoke(president, new object[] { ".NET中的反射技术应用" });

method4.Invoke(null, new object[] { ".NET中的反射技术应用" });//调用静态方法第一个实例可以为null，实例方法不能省略

Console.WriteLine("\r\n----------------------调用泛型方法-------------------------------");
MethodInfo method5 = presidentType.GetMethod("AdvancedWork");
MethodInfo genericMethod5 = method5.MakeGenericMethod(typeof(string), typeof(int));
genericMethod5.Invoke(president, new object[] { "学习.NET中的反射技术应用", 2 });
```

## 基于反射调用字段和属性
```
Type presidentType = Assembly.Load("ReflectionSample").GetType("ReflectionSample.President");
object president = Activator.CreateInstance(presidentType);
//显示全部属性
foreach (PropertyInfo item in presidentType.GetProperties())
{
    Console.WriteLine(item.Name);
}
Console.WriteLine("\r\n--------------------------------------------------");

//显示全部字段
foreach (FieldInfo item in presidentType.GetFields())
{
    Console.WriteLine(item.Name);
}
Console.WriteLine("\r\n--------------------------------------------------");

//给属性赋值
PropertyInfo property = presidentType.GetProperty("School");
property.SetValue(president, "实验小学");
Console.WriteLine(property.GetValue(president));

//给字段赋值
FieldInfo field = presidentType.GetField("schoolSpirit");
field.SetValue(president, "好好学习，天天向上");
Console.WriteLine(field.GetValue(president));//获取字段值
```

## 反射性能测试

对于普通对象的创建（比如我们使用反射创建几个类，性能耗费完全可以忽略）

使用反射过程中，影响程序性能的关键是：程序集加载，也就是我们开发中，一般在项目初始化的时候，需要加载程序集。对于对象创建，是否使用反射方法，几乎可以忽略差别。

```
Stopwatch sw = new Stopwatch();
sw.Start();
for (int i = 0; i < 1000000; i++)
{
    President president = new President();
    president.Test();
}
sw.Stop();
Console.WriteLine("通过直接创建对象调用：" + sw.ElapsedMilliseconds);

sw.Restart();
Assembly ass = Assembly.Load("ReflectionSample");

for (int i = 0; i < 1000000; i++)
{
    President president = (President)ass.CreateInstance("ReflectionSample.President");
    president.Test();
}
sw.Stop();
Console.WriteLine("通过反射方法调用：" + sw.ElapsedMilliseconds);

sw.Restart();
Assembly ass1 = Assembly.Load("ReflectionSample");
Type type = ass1.GetType("ReflectionSample.President");
for (int i = 0; i < 1000000; i++)
{
    President president = (President)Activator.CreateInstance(type);
    president.Test();
}
sw.Stop();
Console.WriteLine("通过反射方法+预定义类型调用：" + sw.ElapsedMilliseconds);
```


