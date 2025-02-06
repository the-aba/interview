import {fetch} from 'expo/fetch'

const makeRequest = async (route: string, method: string, body?: any) => {
    const baseUrl = process.env.EXPO_PUBLIC_API_URL

    const response = await fetch(`${baseUrl}${route}`, {
        method,
        headers: {
            'Content-Type': 'application/json',
        },
        body: body ? JSON.stringify(body) : undefined,
    })
    return await response.json()
}

export {makeRequest}
