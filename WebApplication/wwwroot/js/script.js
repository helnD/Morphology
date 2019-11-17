function drawPixel(element, posX, posY){
    var context = element.getContext("2d");
    var size = {
        width: element.width / 25,
        height: element.height / 25
    };
    var coordinates = {
        x: posX - element.getBoundingClientRect().x,
        y: posY - element.getBoundingClientRect().y
    };
    context.rect(coordinates.x, coordinates.y, 1, 1);
    console.log(coordinates.x + ", " + coordinates.y);
}
