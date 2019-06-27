const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
//const CompressionPlugin = require('compression-webpack-plugin');
//const webpack = require('webpack');

module.exports = (env = {}, argv = {}) => {

    const isProd = argv.mode === 'production';

    const config = {
        mode: argv.mode || 'development', 

        optimization: {
            minimize: true
        },
        entry: {
            main: './src/index.js'
        },
        output: {
            //filename: isProd ? 'bundle-[chunkHash].js' : '[name].js',
            filename: 'GdmStore.bundle.js',
            path: path.resolve(__dirname, '../wwwroot/dist'),
            publicPath: "/dist/"
        },
        plugins: [
            new MiniCssExtractPlugin({
                filename: isProd ? 'style-[contenthash].css' : 'style.css'
            }),
            //new CompressionPlugin({
            //    filename: '[path].gz[query]',
            //    algorithm: 'gzip',
            //    test: /\.js$|\.css$|\.html$|\.eot?.+$|\.ttf?.+$|\.woff?.+$|\.svg?.+$/,
            //    threshold: 10240,
            //    minRatio: 0.8
            //}),
            new HtmlWebpackPlugin({
                //template: '_LayoutTemplate.cshtml',
                template: 'index.html',
                filename: '../index.html', //the output root here is /wwwroot/dist so we ../../      
                inject: false
            })
        ],
        module: {
            rules: [
                {
                    test: /\.js$/,
                    exclude: /(node_modules)/,
                    use: {
                        loader: 'babel-loader',
                    },
                },
                {
                    test: /\.css$/,
                    use: [
                        'style-loader',
                        MiniCssExtractPlugin.loader,
                        'css-loader'
                    ]
                },
                //{
                //    test: /\.css$/,
                //    // use: ['style-loader', 'css-loader'],
                //    use: [{ loader: "style-loader" },
                //        { loader: "css-loader" },
                //        MiniCssExtractPlugin.loader,
                //    ]
                //},
            ],
        }
    };
    return config;
};


