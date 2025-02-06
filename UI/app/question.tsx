import React from 'react'
import {Link} from 'expo-router'
import {StyleSheet, Text, View} from 'react-native'
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
    const {question, loading} = useQuestion()
    const sortedAnswers = question?.answers.sort((a, b) => a.displayOrder - b.displayOrder)
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
                    {sortedAnswers?.map((answer: Answer) => (
                        <View key={answer.answerId} style={styles.answerContainer}>
                            <Text>{answer.text}</Text>
                        </View>
                    ))}
                </>
            )}
            <Link href="/">
                <Text>Go Home</Text>
            </Link>
        </View>
    )
}
