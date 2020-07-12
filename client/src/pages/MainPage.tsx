import React, { Fragment } from 'react';
import { Grid } from '@chakra-ui/core';
import { NavigationBar } from '../components/layout/NavigationBar';
import { SideBar } from '../components/layout/SideBar';
import { NoteEditor } from '../components/editor/NoteEditor';

export const MainPage = () => {
  return (
    <Fragment>
      <NavigationBar />
      <Grid templateColumns='20% 1fr' gap={5}>
        <SideBar />
        <NoteEditor />
      </Grid>
    </Fragment>
  );
};
