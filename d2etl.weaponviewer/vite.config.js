import react from '@vitejs/plugin-react';
import { dirname, resolve } from 'node:path'
import { fileURLToPath } from 'node:url'
import { defineConfig } from 'vite'

const __dirname = dirname(fileURLToPath(import.meta.url))


// https://vitejs.dev/config/
export default defineConfig({
    plugins: [react()],
    server: {
        port: 8001,
    },
})