class Shape {
    constructor(context, color) {
        this.context = context;
        this.color = color;
    }

    clearCanvas() {
        this.context.clearRect(0, 0, this.context.canvas.width, this.context.canvas.height);
    }
}

class Circle extends Shape {
    constructor(context, color, x, y, radius) {
        super(context, color);
        this.x = x;
        this.y = y;
        this.radius = radius;
    }

    draw() {
        this.context.beginPath();
        this.context.arc(this.x, this.y, this.radius, 0, 2 * Math.PI);
        this.context.fillStyle = this.color;
        this.context.fill();
    }
}

class Rectangle extends Shape {
    constructor(context, color, x, y, width, height) {
        super(context, color);
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }

    draw() {
        this.context.fillStyle = this.color;
        this.context.fillRect(this.x, this.y, this.width, this.height);
    }
}

const canvas = document.getElementById("platno");
const context = canvas.getContext("2d");

const circle = new Circle(context, "blue", 100, 100, 50);
const rectangle = new Rectangle(context, "green", 200, 200, 100, 100);

function draw() {
    circle.clearCanvas();
    rectangle.clearCanvas();

    circle.draw();
    rectangle.draw();

    requestAnimationFrame(draw);
}

function handleMouseMove(event) {
    circle.x = event.clientX;
    circle.y = event.clientY;
}

canvas.addEventListener("mousemove", handleMouseMove);

draw();
