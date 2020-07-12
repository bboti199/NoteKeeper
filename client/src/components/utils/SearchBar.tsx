import React, { useState, useEffect, ChangeEvent } from 'react';
import {
  Input,
  Flex,
  InputGroup,
  InputLeftElement,
  InputRightElement,
} from '@chakra-ui/core';
import { Search, XCircle } from '@zeit-ui/react-icons';

export const SearchBar = () => {
  const [searchTerm, setSearchTerm] = useState<string>('');
  const [clearVisible, setClearVisible] = useState<boolean>(false);

  const handleTermChange = (e: ChangeEvent<HTMLInputElement>) => {
    setSearchTerm(e.target.value);
  };

  const clearSearchBar = () => {
    setSearchTerm('');
    setClearVisible(false);
  };

  useEffect(() => {
    if (searchTerm === '' || searchTerm === null) {
      setClearVisible(false);
    }

    if (searchTerm && !clearVisible) {
      setClearVisible(true);
    }
  }, [searchTerm, clearVisible]);

  return (
    <Flex my={5} width='100%' px={5}>
      <InputGroup width='100%'>
        <InputLeftElement children={<Search size={20} color='#888' />} />
        <Input
          placeholder='Search in your notes...'
          variant='filled'
          borderRadius={30}
          onChange={handleTermChange}
          value={searchTerm}
          focusBorderColor='#000'
        />
        {clearVisible ? (
          <InputRightElement
            children={<XCircle size={20} />}
            onClick={clearSearchBar}
          />
        ) : null}
      </InputGroup>
    </Flex>
  );
};
