import {Link} from 'expo-router'
import {Text, View} from 'react-native'

export default function Index() {
    return (
        <View
            style={{
                flex: 1,
                justifyContent: 'center',
                alignItems: 'center',
            }}
        >
            <Link href="/question">
                <Text>Click here to get a random question.</Text>
            </Link>
            <Link href="/responses">
                <Text>Click here to view responses.</Text>
            </Link>
        </View>
    )
}
