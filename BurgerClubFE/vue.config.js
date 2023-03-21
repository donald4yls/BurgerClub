module.exports = {
    devServer: {
        port: 8888,
        proxy:{
            "/api":{
                target: 'https://localhost:44380',
                changeOrigin: true
            }
        }
    },
    lintOnSave: false
}
