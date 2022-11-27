import Genre from "./GenreEnum";

interface IGame {
    id?: number;
    title: string;
    genre: Genre;
    platform: string;
    developer: string;
    publisher: string;
    releaseDate: Date; // var string
    price: number;
    rating: number;
    description: string;
    image: string;
}

export default IGame;