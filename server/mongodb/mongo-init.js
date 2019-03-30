db.createUser({
  user: "app-user",
  pwd: "gr43tq0tes!",
  roles: [{ role: "readWrite", db: "great-quotes" }],
  mechanisms: ["SCRAM-SHA-256"]
});

db.createCollection("quotes");
db.quotes.insertMany([
  {
    author: "Albert Einstein",
    content:
      "La folie, c'est de faire toujours la même chose et de s'attendre à un résultat différent"
  },
  {
    author: "Antoine de Saint-Exupéry",
    content:
      "La perfection est atteinte, non pas lorsqu'il n'y a plus rien à ajouter, mais lorsqu'il n'y a plus rien à retirer"
  }
]);
