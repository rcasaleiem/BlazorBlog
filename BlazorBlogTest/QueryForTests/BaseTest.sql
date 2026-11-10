DROP DATABASE myblog;
USE myblog;

INSERT INTO users (username, password, role, creationDate)
VALUES ('userTest', 'test', 'ADMIN', NOW());

INSERT INTO Posts (content, cathegory, tags, creationDate)
VALUES ('This is just a test.', 'test', 'test, test2', NOW());

INSERT INTO comments (content, authorId, postId, rispostaA, creationDate)
VALUES ('This is just a test.posttotags', 1, 1, 0, NOW());

TRUNCATE TABLE users;
TRUNCATE TABLE Posts;
TRUNCATE TABLE comments;
TRUNCATE TABLE tags;
TRUNCATE TABLE cathegories;

DELETE FROM comments;

SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE comments;
TRUNCATE TABLE users;
SET FOREIGN_KEY_CHECKS = 1;