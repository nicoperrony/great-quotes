db.createCollection("quotes");
db.quotes.insertMany([
  {
    author: "Albert Einstein",
    quote:
      "La folie, c'est de faire toujours la même chose et de s'attendre à un résultat différent"
  },
  {
    author: "Antoine de Saint-Exupéry",
    quote:
      "La perfection est atteinte, non pas lorsqu'il n'y a plus rien à ajouter, mais lorsqu'il n'y a plus rien à retirer"
  }
]);
