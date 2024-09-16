import { fileURLToPath, URL } from 'node:url'

import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [
    vue(),
  ],
  resolve: {
    alias: {
      '@': fileURLToPath(new URL('./src', import.meta.url))
    }
  },
  server: {
    proxy: { // 跨域代理
        '/api': { // 请求接口，/api 是替换关键字，会替换api/* 目录下的请求接口函数中的url地址然后进行拼接
            target: 'http://192.168.31.62:8093',  // 实际请求的服务器地址 上面的 “/api” 在axios里就是指向这个实际的地址
            changeOrigin: true, // 是否允许跨域
            ws: false,  // webStock 请求
            rewrite: (path) => path.replace(/^\/api/, '') // 处理替换的函数 api是替换的关键字
        }
    }
  }  
})
