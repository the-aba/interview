import {useEffect, useState} from 'react'
import {makeRequest} from '@/api'

interface Answer {
    answerId: number
    text: string
    displayOrder: number
}

interface Question {
    questionId: number
    text: string
    answers: Answer[]
}

const useQuestion = () => {
    const [question, setQuestion] = useState<Question | null>(null)
    const [loading, setLoading] = useState<boolean>(true)

    useEffect(() => {
        const getRandomQuestion = async () => {
            try {
                const questionData = await makeRequest('questions/random', 'GET')
                setQuestion(questionData)
            } catch (error) {
                console.error(error)
            } finally {
                setLoading(false)
            }
        }
        getRandomQuestion()
    }, [])

    return {question, loading}
}

export default useQuestion
export {Question, Answer}
