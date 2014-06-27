(function () {
    require.config({
        paths: {
            main: "snake-main",
            engine: "snake-engine",
            objects: "snake-objects",
            renderer: "snake-renderer"
        }
    });

    require(["main"]);
    require(["objects"]);
    require(["renderer"]);
    require(["engine"]);

}());

