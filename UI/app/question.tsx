import React, {useState} from 'react'
import {Link, router} from 'expo-router'
import {Button, StyleSheet, Text, View, TouchableOpacity} from 'react-native'
import useQuestion, {Answer} from '@/hooks/useQuestion'

const styles = StyleSheet.create({
    container: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
    },
    questionContainer: {
        padding: 20,
        marginBottom: 10,
        backgroundColor: '#f0f0f0',
        borderRadius: 10,
        width: 700,
        maxWidth: '90%',
    },
    answerContainer: {
        padding: 10,
        backgroundColor: '#d0d0d0',
        borderRadius: 10,
        marginVertical: 10,
        width: 700,
        maxWidth: '90%',
    },
    questionSeparator: {
        width: 700,
        maxWidth: '90%',
        height: 1,
        backgroundColor: '#000',
        marginVertical: 20,
    },
})

export default function Index() {
    const {question, loading, submitResponse} = useQuestion()
    const sortedAnswers = question?.answers.sort((a, b) => a.displayOrder - b.displayOrder)
    const [selectedAnswer, setAnswer] = useState('')
    return (
        <View style={styles.container}>
            {loading && <Text>Loading...</Text>}
            {!loading && !question && <Text>Failed to load question.</Text>}
            {!loading && question && (
                <>
                    <View style={styles.questionContainer}>
                        <Text>{question.text}</Text>
                    </View>
                    <View style={styles.questionSeparator} />
                    {sortedAnswers?.map((answer: Answer) => {
                        const styleToUse =
                            answer.text == selectedAnswer
                                ? [
                                      styles.answerContainer,
                                      {borderColor: '#000000', borderStyle: 'solid', borderWidth: 2},
                                  ]
                                : styles.answerContainer
                        return (
                            <TouchableOpacity
                                key={answer.answerId}
                                style={styleToUse}
                                onPress={() => {
                                    setAnswer(answer.text)
                                }}
                            >
                                <Text>{answer.text}</Text>
                            </TouchableOpacity>
                        )
                    })}
                    <Button
                        title="Submit"
                        onPress={() => {
                            let answerId = sortedAnswers?.find(
                                (answer: Answer) => answer.text == selectedAnswer,
                            )?.answerId
                            if (answerId) {
                                submitResponse(answerId, question.questionId)
                            }
                            router.push('/')
                        }}
                    />
                </>
            )}
            <Link href="/">
                <Text>Go Home</Text>
            </Link>
        </View>
    )
}
