# Что такое SimpleDraw?
SimpleDraw - библиотека для отрисовки, направленная на упрощение работы с графикой. Основана на [SFD](https://github.com/etar125/SFD). На самом деле я просто хотел переписать либу и упростить написание своего игрового движка.
# Начало работы с SimpleDraw
Для начала [скачайте библиотеку](https://github.com/etar125/SimpleDraw/releases). Создайте проект Windows Forms. Добавьте ссылку на библиотеку. Присоедините её:
```cs
using simpledraw.Drawing;
using simpledraw.Objects.Default;
```
Создайте событие загрузки формы, нажав два раза по ней, и напишите такой код:
```cs
SimpleDrawing main = new SimpleDrawing(); // Создаём экземпляр класса
main.queue.Add(new Line(Pens.Red, new PointF(2f, 66f), new PointF(66f, 66f))); // Добавляем фигуры в очередь на отриску
main.queue.Add(new Line(Pens.Red, new PointF(34f, 66f), new PointF(34f, 2f)));
main.queue.Add(new Box(new Point(1, 1), new Size(66, 67), Pens.Black, Brushes.Black, false));
main.queue.Add(new Ellipse(new Point(4, 4), new Size(16, 16), Pens.Pink, Brushes.Pink, true));
main.CreateBuffer(this); // Отрисовываем в буфер
main.Request(this); // Отрисовываем буфер
```
Если вы сделали всё правильно, у вас должно получиться так:  
![image](https://github.com/etar125/SimpleDraw/assets/116297277/65a1d976-a316-4b63-b04b-279ba8d79123)

*Написано для версии 0.02*
