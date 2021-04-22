import React, { Component } from 'react';

export class Movie extends Component {
    static displayName = Movie.name;

    constructor(props) {
        super(props);
        this.state = { movies: [], loading: true };
    }

    componentDidMount() {
        this.populateMoviesData();
    }

    static renderMoviesTable(movies) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Year</th>
                        <th>Genre(s)</th>
                        <th>Director</th>
                        <th>Actors</th>
                        <th>IMDB Rating</th>
                    </tr>
                </thead>
                <tbody>
                    {movies.map(movie =>
                        <tr key={movie.title}>
                            <td>{movie.title}</td>
                            <td>{movie.year}</td>
                            <td>{movie.genre}</td>
                            <td>{movie.director}</td>
                            <td>{movie.actors}</td>
                            <td>{movie.imdbRating}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Movie.renderMoviesTable(this.state.movies);

        return (
            <div>
                <h1 id="tabelLabel" >Our Movies</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateMoviesData() {
        const response = await fetch('movie');
        const data = await response.json();
        this.setState({ movies: data, loading: false });
    }
}
