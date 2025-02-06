import {Link} from 'expo-router'
import {useEffect, useState} from 'react'
import {Text, View, ScrollView} from 'react-native'
import {fetch} from 'expo/fetch'

export default function Index() {
    const [responses, setResponses] = useState([])
    useEffect(() => {
        fetch('https://localhost:7163/questions/get-responses-route').then((response) => {
            response.json().then((data) => {
                setResponses(data)
            })
        })
    }, [])

    var questionResponse = responses[0]

    return (
        <ScrollView
            style={{
                flex: 1,
            }}
        >
            <View style={{width: '100%', alignItems: 'center', marginVertical: 20}}>
                {questionResponse &&
                    responses.map((response, index) => (
                        <View
                            key={index}
                            style={{
                                marginBottom: 20,
                                backgroundColor: 'lightgray',
                                padding: 10,
                                width: 700,
                            }}
                        >
                            <Text style={{fontWeight: 'bold'}}>Question:</Text>
                            <Text>{questionResponse.question}</Text>
                            <Text style={{fontWeight: 'bold'}}>Your Answer:</Text>
                            <Text>{response.answer}</Text>
                        </View>
                    ))}
                <Link href="/">Back to Home</Link>
            </View>
        </ScrollView>
    )
}
