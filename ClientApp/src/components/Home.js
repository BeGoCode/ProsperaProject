import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Hello, Prospera!</h1>
        <p>Welcome to your new weather and movies app! It is built with:</p>
        <ul>
          <li>ASP.NET Core and C# server-side code</li>
          <li>React for client-side code</li>
          <li>Bootstrap for layout and styling</li>
        </ul>
      </div>
    );
  }
}
