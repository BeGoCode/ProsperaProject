import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Weather } from './components/Weather';
import { Movie } from './components/Movie';
import background from './Imgaes/HireMeBackground.jpg'

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
      return (
          <div className='backgroundContainer'>
          <div className='backgroundImg'>
          </div>
              <Layout>
                  <div >
                    <Route exact path='/' component={Home} />
                    <Route path='/movie' component={Movie} />
                    <Route path='/weather' component={Weather} />
                </div>
              </Layout>
              </div>
    );
  }
}
