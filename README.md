# 2-2.5-
C# (属性和单例，有两种基本的方式1.只读属性Hp public int Hp{get;private set;}第二种是完整的写法private int attack;public int Attack{set{return attack;}set{attack=value;}}在类的外面，可以读取Hp属性但不能修改；可以随意读取和修改Attack属性）
