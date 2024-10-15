import {StyleSheet, Text, View} from 'react-native';
import React from 'react';
import {NativeModules} from 'react-native';
import {Button} from 'react-native-windows';
const {FilePickerModule} = NativeModules;

const App = () => {
  const openFilePicker = async () => {
    console.log(FilePickerModule);
    try {
      const filePath = await FilePickerModule.openFilePicker();
      if (filePath) {
        console.log('Selected file path:', filePath);
      } else {
        console.log('No file selected');
      }
    } catch (error) {
      console.error('Error opening file picker:', error);
    }
  };

  return (
    <View>
      <Text>App</Text>
      <Button title="test" onPress={openFilePicker} />
    </View>
  );
};

export default App;

const styles = StyleSheet.create({});
