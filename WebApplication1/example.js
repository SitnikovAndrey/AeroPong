function circle(x, y, r) // класс задающий круг
{
    this.x = x; // координата х
    this.y = y; // координата у
    this.r = r; // радиус
    this.draw = function (color, globalAlpha) // метод рисующий круг
    {
        context.globalAlpha = globalAlpha; // "прозрачность"
        context.fillStyle = color; // цвет заливки
        context.beginPath();
        context.arc(this.x, this.y, this.r, 0, Math.PI * 2, true);
        context.fill();
    };
}

function rect(x, y, width, height) // класс задающий прямоугольник
{
    this.x = x; // координата х
    this.y = y; // координата у
    this.width = width; // ширина
    this.height = height; // высота
    this.draw = function (color, globalAlpha) // функция рисует прямоугольник согласно заданным параметрам
    {
        context.globalAlpha = globalAlpha;
        context.fillStyle = color;
        context.fillRect(this.x, this.y, this.width, this.height);
    };
}
// движение игрока
//function playerMove(e) {
//    var x = e.pageX;
//    if ( niz.width < x && x < game.width  ) {
//        niz.x = x/3;
//    }
//}
function playerMove(e) {
    var x = e.pageX;
    if (game.width - niz.width / 2 < x && x < game.width + 5*niz.width-20) {
      niz.x = x-game.width+niz.width/2;
    }
}
function collision(objA, objB) {
    if (objA.x + objA.width > objB.x + objB.r &&
        objA.x < objB.x + objB.r &&
        objA.y + objA.height > objB.y+objB.r &&
        objA.y < objB.y + objB.r)
        {
        return true;
    }
    else {
        return false;
    }
}
function collision2(objA, objB) {
    if (objA.x + objA.width > objB.x + objB.r &&
        objA.x < objB.x + objB.r &&
        objA.y -objA.height > objB.y+ objB.r&&
        objA.y > objB.y) {
        return true;
    }
    else {
        return false;
    }
}
function update() // изменения координат которые нужно произвести
{
    //if (ball.y - ball.r < 0 || ball.y + ball.r > 600) // соприкосновение с "полом" и "потолком" холста
    //{
    //    vY = -vY;
    //}
     if (ball.y-ball.r < 0) {
        vY = -vY;
        verx.scores++;
    }
    if (ball.y + ball.r > game.height) {
        vY = -vY;
        niz.scores++;
    }
    if (ball.x - ball.r < 0 || ball.x + ball.r > 500) // соприкосновение с левой и правй "стенкой" холста 
    {
        vX = -vX;
    }
    if ((collision2(verx, ball) && vY <0 ) || (collision(niz, ball) && vY > 0)) {
        vY = -vY;
    }
    aiMove();
    // приращение координат
    ball.x += vX;
    ball.y += vY;
    

}
function aiMove() {
    var x;
    // делаем скорость оппонента на две единицы меньше чем скорость шарика
    if (ball.x < verx.x ) {
        //x = verx.x - vX;
        verx.x = verx.x - vX;
    }
    else {
        //x = verx.x + vX;
        verx.x = verx.x + vX;
    }
    //if ( x > verx.x) {
    //    verx.x = x;
    //}
}
function draw() // рисуем на холсте
{
    game.draw("#000", 1); // рисуем фон
    context.font = 'bold 128px courier';
    context.textAlign = 'center';
    context.textBaseline = 'top';
    context.fillStyle = '#ccc';
    context.fillText(niz.scores, 50, 0);
    context.fillText(verx.scores, 50, game.height-135);
    for (var i = 10; i < game.width; i += 45) // линия разделяющая игровое поле на две части
    {
        context.fillStyle = "#ccc";
        context.fillRect(i, game.width / 2+30,30, 15);
    }
    niz.draw("#f00", 1);// рисуем нижнии прямоугольник
    verx.draw("#f00", 1);// рисуем нижнии прямоугольник
    ball.draw("#fff", 1); // рисуем шар
    //update(); // обновляем координаты
}
function play() {
    draw(); // отрисовываем всё на холсте
    update(); // обновляем координаты
   
}
function init() // Инициализация переменных
{
    game = new rect(0, 0, 500, 600); // прямоугольник закрашивающий фон
    niz = new rect(game.width / 2-40, game.height - 30, 80, 20);  // прямоугольник внизу фон
    verx = new rect(game.width/2 - 40, 10, 80, 20);
    ball = new circle(game.width / 2, game.height / 2, 10); // шар 
    niz.scores = 0;
    verx.scores = 0;
    vX = 3; // скорость шара по оси х
    vY = 3; // скорость шара по оси у
    var canvas = document.getElementById("example");
    canvas.width = game.width; // ширина холста
    canvas.height = game.height; // высота холста
    context = canvas.getContext("2d");
    canvas.onmousemove = playerMove;
    setInterval(play, 1000 / 50); //отрисовываем 50 раз за секунду
}