import React from 'react';
import { Flex, Text, Divider, Box } from '@chakra-ui/core';
import { SearchBar } from '../utils/SearchBar';

export const SideBar = () => {
  return (
    <Flex
      direction='column'
      borderRightWidth={1}
      borderRightColor='#ccc'
      alignItems='flex-start'
      justifyContent='flex-start'
      height='85vh'
    >
      <Box width='100%' px={5}>
        <Text fontSize='3xl' fontWeight='medium'>
          Your Notes
        </Text>
        <Divider />
      </Box>
      <SearchBar />
    </Flex>
  );
};
