import axios, {AxiosResponse} from 'axios'; 
import { request } from 'http';
import { toast } from 'react-toastify';
import { IBusiness } from '../models/business';
import {history} from '..';

// axios.defaults.headers = {
//     'Access-Control-Allow-Origin' : '*',
//     'Access-Control-Allow-Methods' : 'GET,PUT,POST,DELETE,PATCH,OPTIONS',
// }

axios.defaults.baseURL = 'https://localhost:5001/api';

axios.interceptors.response.use(undefined, error => {
    if (error.message === 'Network Error' && !error.response) {
        toast.error('Network error - make sure API is running!')
    }
    const {status, data, config} = error.response;
    if (status === 404) {
        history.push('/notfound')
    }
    if (status === 400 && config.method === 'get' && data.errors.hasOwnProperty('id')) {
        history.push('/notfound')
    }
    if (status === 500) {
        toast.error('Server error - check the terminal for more info!')
    }
    throw error;
})

const responseBody = (response: AxiosResponse) => response.data;

const requests = {
    get: (url: string) => axios.get(url).then(responseBody),
    post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
    put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
    del: (url: string) => axios.delete(url).then(responseBody),
}

const Businesses = {
    list: (): Promise<IBusiness[]> => requests.get('/Businesses'),
    details: (id: string) => requests.get(`/Businesses/${id}`),
    create: (business: IBusiness) => requests.post('/Businesses', business)
}

const agent = {
    Businesses
}

export default agent; 
