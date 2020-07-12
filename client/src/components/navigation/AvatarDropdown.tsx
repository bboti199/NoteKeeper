import React from 'react';
import {
  Avatar,
  Flex,
  Menu,
  MenuButton,
  MenuList,
  MenuItem,
  Divider,
  Text,
  Box,
} from '@chakra-ui/core';
import { ChevronDown } from '@zeit-ui/react-icons';
import { User, LogOut, Settings } from '@zeit-ui/react-icons';

export const AvatarDropdown = () => {
  return (
    <Menu>
      <MenuButton>
        <Flex flexDirection='row' alignItems='center' cursor='pointer' mr={2}>
          <Avatar
            src='https://api.adorable.io/avatars/400/f13ee198b38019b762dd2cb296a1cf94.png'
            size='md'
            mr={2}
          />
          <ChevronDown size={30} />
        </Flex>
      </MenuButton>
      <MenuList>
        <MenuItem>
          <Text>
            Welcome, <b>jdoe</b>!
          </Text>
        </MenuItem>
        <Divider />
        <MenuItem>
          <User size={24} />
          <Box mx={2} />
          <span>Profile</span>
        </MenuItem>
        <MenuItem>
          <Settings size={24} />
          <Box mx={2} />
          <span>Settings</span>
        </MenuItem>
        <Divider />
        <MenuItem>
          <LogOut size={24} />
          <Box mx={2} />
          <span>Log Out</span>
        </MenuItem>
      </MenuList>
    </Menu>
  );
};
