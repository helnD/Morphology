var clicked = false;
var matrix = [];

function componentToHex(c) {
    var hex = c.toString(16);
    return hex.length === 1 ? "0" + hex : hex;
}

function drawPixel(element, parameters){
    
    for (var i = 0; i < matrix.length; i++) {
        if(matrix[i].x === parameters.coordinate.x && matrix[i].y === parameters.coordinate.y) {
            return;
        }
    }

    matrix.push(parameters.coordinate);
    
    var position = {
        x: parameters.size.width * parameters.coordinate.x,
        y: parameters.size.height * parameters.coordinate.y
    };
        
    var context = element.getContext("2d");
    context.fillRect(position.x, position.y, parameters.size.width, parameters.size.height);
}

function drawPixelByCoordinate(coordinate, color){

    var element = document.getElementById("result");
    
    var rectSize = {
        width: element.offsetWidth / 25,
        height: element.offsetHeight / 25
    };

    var context = element.getContext("2d");
    
    context.fillStyle = "#" + componentToHex(color.r) + componentToHex(color.g) + componentToHex(color.b);
    console.log(coordinate.x * rectSize.width, coordinate.y * rectSize.height, rectSize.width, rectSize.height, context.fillStyle);
    context.fillRect(coordinate.x * rectSize.width, coordinate.y * rectSize.height, rectSize.width, rectSize.height);
}

function canvasOnMouseDown(element, posX, posY) {
    clicked = true;
    var parameters = getParameters(element, posX, posY);
    drawPixel(element, parameters);
}

function canvasOnMouseUp() {
    clicked = false;
}

function canvasOnMouseMove(element, posX, posY) {
    if (clicked) {
        var parameters = getParameters(element, posX, posY);
        drawPixel(element, parameters);
    }
}

function getParameters(element, posX, posY) {
    
    var rectSize = {
        width: element.offsetWidth / 25,
        height: element.offsetHeight / 25
    };

    var mousePosition = {
        x: posX - element.getBoundingClientRect().x,
        y: posY - element.getBoundingClientRect().y
    };

    var coordinate = {
        x: Math.floor(mousePosition.x / rectSize.width),
        y: Math.floor(mousePosition.y / rectSize.height)
    };
    
    return {
        size: rectSize,
        coordinate: coordinate
    }
}

function drawResult(matrix) {
    
    for (var y = 0; y < matrix.length; y++) {
        
        for (var x = 0; x < matrix.length; x++) {
            
            drawPixelByCoordinate({x: x, y: y}, matrix[y][x]);
        }
    }
}

function request() {
    
    var body = "?";
    for (var i = 0; i < matrix.length; i++) {

        if(i !== 0) {
            body += '&';
        }
        
        body += "x" + i + "=" + matrix[i].x + "&";
        body += "y" + i + "=" + matrix[i].y;
    }
    
    body += "&operation=";
    
    var inc = document.getElementById("increasing");
    if (inc.checked) body += "incr";
    var ero = document.getElementById("erosion");
    if (ero.checked) body += "eros";
    var loc = document.getElementById("locking");
    if (loc.checked) body += "clos";
    var unloc = document.getElementById("unlocking");
    if (unloc.checked) body += "uloc";
    
    var xhr = new XMLHttpRequest();
    xhr.open('GET', "https://localhost:5001/Home/Index" + body, false);
    xhr.send();
    drawResult(JSON.parse(xhr.response))
}