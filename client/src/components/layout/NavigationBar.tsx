import React from 'react';
import { Flex, Box, Text } from '@chakra-ui/core';
import { AvatarDropdown } from '../navigation/AvatarDropdown';

export const NavigationBar = () => {
  return (
    <Flex
      direction='row'
      alignItems='center'
      justifyContent='space-between'
      px={5}
      py={3}
      mb={10}
      boxShadow='0px 1px 10px 0px rgba(0,0,0,0.1)'
      borderBottomLeftRadius={5}
      borderBottomRightRadius={5}
    >
      <Box>
        <Text fontSize='4xl' fontWeight='bold'>
          NoteKeeper
        </Text>
      </Box>
      <AvatarDropdown />
    </Flex>
  );
};
