import React from 'react';

interface BookPageProps {
  match: {
    params: {
      id: string;
    };
  };
}

const BookPage: React.FC<BookPageProps> = ({ match }) => {
  const bookId = match.params.id;

 
  return (
    <div>
      <h1>Страница книги</h1>
      <p>Книга ID: {bookId}</p>
      {}
    </div>
  );
};

export default BookPage;
