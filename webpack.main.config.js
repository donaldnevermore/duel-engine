const path = require("path")

module.exports = {
    /**
   * This is the main entry point for your application, it's the first file
   * that runs in the main process.
   */
    entry: "./src/index.ts",
    // Put your normal webpack config below here
    module: {
        rules: require("./webpack.rules"),
    },
    resolve: {
        extensions: [".js", ".ts", ".jsx", ".tsx", ".css", ".json"],
        alias: {
            components: path.resolve(__dirname, "src/components"),
            lib: path.resolve(__dirname, "src/lib")
        }
    },
}
